using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace AutoMapperSandbox
{

	public class Animal
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}




	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}





	class Program
	{

		/// <summary>
		/// Maps an object instance to an instance of the same object type.
		/// </summary>
		private static void Example1()
		{
			Mapper.Reset();
			Mapper.CreateMap<Animal, Animal>();
		
			Animal cat = new Animal { Name = "Hank", Age = 3};
		
			Animal dog = Mapper.Map<Animal>(cat);
		
			Console.WriteLine("cat type is {0}", cat.GetType());
			Console.WriteLine("dog type is {0}", dog.GetType());

			Console.WriteLine("cat.Name={0} cat.Age={1}", cat.Name, cat.Age);
			Console.WriteLine("dog.Name={0} dog.Age={1}", dog.Name, dog.Age);
		}




		/// <summary>
		/// Maps an object instance to an instance of another object type.
		/// </summary>
		private static void Example2()
		{
			Mapper.Reset();
			Mapper.CreateMap<Animal, Person>();
		
			Animal cat = new Animal { Name = "Hank", Age = 3};
		
			Person jay = Mapper.Map<Person>(cat);
		
			Console.WriteLine("cat type is {0}", cat.GetType());
			Console.WriteLine("jay type is {0}", jay.GetType());

			Console.WriteLine("cat.Name={0} cat.Age={1}", cat.Name, cat.Age);
			Console.WriteLine("jay.Name={0} jay.Age={1}", jay.Name, jay.Age);
		}




		/// <summary>
		/// Maps an object instance to another object instance and ignores a property.
		/// </summary>
		private static void Example3()
		{
			Mapper.Reset();
			Mapper.CreateMap<Animal, Person>()
				.ForMember(person => person.Age, opt => opt.Ignore());

			Animal cat = new Animal { Name = "Hank", Age = 3};
		
			Person jay = Mapper.Map<Person>(cat);
		
			Console.WriteLine("cat type is {0}", cat.GetType());
			Console.WriteLine("jay type is {0}", jay.GetType());

			Console.WriteLine("cat.Name={0} cat.Age={1}", cat.Name, cat.Age);
			Console.WriteLine("jay.Name={0} jay.Age={1}", jay.Name, jay.Age);
		}





		/// <summary>
		/// Maps an object instance to another object instance and conditionally copies a given property.
		/// </summary>
		private static void Example4(int ageLimit)
		{
			Mapper.Reset();
			Mapper.CreateMap<Animal, Person>()
				.ForMember(person => person.Age, opt => opt.Condition(animal => (animal.Age >= ageLimit)));

			Animal cat = new Animal { Name = "Hank", Age = 3};
		
			Person jay = Mapper.Map<Person>(cat);
		
			Console.WriteLine("cat type is {0}", cat.GetType());
			Console.WriteLine("jay type is {0}", jay.GetType());

			Console.WriteLine("cat.Name={0} cat.Age={1}", cat.Name, cat.Age);
			Console.WriteLine("jay.Name={0} jay.Age={1}", jay.Name, jay.Age);
		}



	
		private static void Main(string[] args)
		{
			Console.WriteLine("\n========== Example 1 ==========\n");
			Example1();
			Console.WriteLine("\n========== Example 2 ==========\n");
			Example2();
			Console.WriteLine("\n========== Example 3 ==========\n");
			Example3();
			Console.WriteLine("\n========== Example 4 (age limit 0) ==========\n");
			Example4(0);
			Console.WriteLine("\n========== Example 4 (age limit 5) ==========\n");
			Example4(5);

			Console.ReadKey();
		}
	}
}
