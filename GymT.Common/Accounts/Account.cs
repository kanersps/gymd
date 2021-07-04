using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using GymT.Common.Exercises;
using GymT.Common.View.Account;
using GymT.Common.View.Exercises;
using Microsoft.IdentityModel.Tokens;

namespace GymT.Common.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Exercise> Exercises { get; set; } = new();

        public string GenerateToken()
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            
            byte[] key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("GYMT_SECRET") ?? "This should probably not be your key");
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AccountDashboard GetDashboard()
        {
            return new AccountDashboard()
            {
                Nickname = Nickname
            };
        }

        public ExerciseCreatorError CreateExercise(ExerciseCreate exerciseCreate, ExerciseEquipment equipment)
        {
            Exercise exercise = new Exercise()
            {
                Equipment = equipment,
                Name = exerciseCreate.Name,
                Created = DateTime.UtcNow,
                Author = this
            };
            
            List<ExerciseMove> Moves = exerciseCreate.Moves.Select((move, index) => new ExerciseMove()
            {
                DefaultAmount = move.DefaultAmount,
                Name = move.Name,
                Instructions = move.Instructions,
                Order = index,
                QuantityType = move.QuantityType,
                ExerciseMoveUsers = new List<ExerciseMoveUser>(),
                Exercise = exercise,
                DefaultRepetitions = move.DefaultRepetitions
            }).ToList();

            exercise.Moves = Moves;
            
            Exercises.Add(exercise);

            return ExerciseCreatorError.NoError;
        }

        public ExerciseViewResponse GetExercises(ExerciseViewRequest request)
        {
            List<ExerciseView> exerciseViews = Exercises.OrderBy(exercise => exercise.Created).Where(exercise => request.NextPage ? exercise.Created > request.LastView : exercise.Created < request.LastView).Take(10).Select(exercise => new ExerciseView()
            {
                Name = exercise.Name,
                Equipment = exercise.Equipment?.Name,
                Created = exercise.Created
            }).ToList();

            return new ExerciseViewResponse()
            {
                Pages = (int)Math.Ceiling(Exercises.Count / 10.0),
                Exercises = exerciseViews
            };
        }
    }
}