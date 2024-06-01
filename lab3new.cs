using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingApp
{
    // Интерфейс "Упражнение"
    public interface IExercise
    {
        string Name { get; set; }
        int Weight { get; set; }
        string ToString();
    }

    // Класс "Упражнение со штангой"
    public class BarbellExercise : IExercise
    {
        public string Name { get; set; }  // Название упражнения
        public int Weight { get; set; }   // Вес штанги

        public BarbellExercise(string name, int weight)
        {
            Name = name ?? throw new ArgumentNullException(nameof(Name));
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} with {Weight} kg";
        }
    }

    // Класс "Упражнение с гантелями"
    public class DumbbellExercise : IExercise
    {
        public string Name { get; set; }  // Название упражнения
        public int Weight { get; set; }   // Вес гантели

        public DumbbellExercise(string name, int weight)
        {
            Name = name ?? throw new ArgumentNullException(nameof(Name));
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} with {Weight} kg";
        }
    }

    // Обобщенный класс "Тренировка"
    public class Training<T> where T : IExercise
    {
        public List<T> Exercises { get; private set; } // Коллекция упражнений

        public Training(IEnumerable<T> exercises)
        {
            if (exercises == null)
            {
                throw new ArgumentException("Exercises cannot be null");
            }
            Exercises = new List<T>(exercises);
        }

        // Метод для вывода выполненных упражнений
        public void DisplayExercises()
        {
            Console.WriteLine("Completed the following exercises:");
            foreach (var exercise in Exercises)
            {
                Console.WriteLine(exercise.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание упражнений со штангой
            var barbellExercises = new List<BarbellExercise>
            {
                new BarbellExercise("Bench Press", 100),
                new BarbellExercise("Deadlift", 150)
            };

            // Создание упражнений с гантелями
            var dumbbellExercises = new List<DumbbellExercise>
            {
                new DumbbellExercise("Bicep Curl", 20),
                new DumbbellExercise("Shoulder Press", 30)
            };

            // Создание тренировки с упражнениями со штангой
            var barbellTraining = new Training<BarbellExercise>(barbellExercises);

            // Создание тренировки с упражнениями с гантелями
            var dumbbellTraining = new Training<DumbbellExercise>(dumbbellExercises);

            // Вывод упражнений со штангой
            Console.WriteLine("Barbell Training:");
            barbellTraining.DisplayExercises();

            // Вывод упражнений с гантелями
            Console.WriteLine("\nDumbbell Training:");
            dumbbellTraining.DisplayExercises();
        }
    }
}