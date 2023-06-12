using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductionClassLibrary
{
    public interface IProduction
    {
        string Name { get; set; }
        string Produce();
        string Sell();
    }

    public abstract class Factory : IProduction
    {
        public string Name { get; set; }
        public int Employees { get; set; }
        public bool IsOpen { get; set; }

        public abstract string Produce();

        public virtual string Sell()
        {
            return "Товары проданы";
        }

        public string OpenFactory()
        {
            IsOpen = true;
            return "Завод открыт";
        }

        public string CloseFactory()
        {
            IsOpen = false;
            return "Завод закрыт";
        }
    }

    public class BrickFactory : Factory
    {
        public int BrickCount { get; set; }

        public override string Produce()
        {
            BrickCount += 1000;
            return "Производство кирпичей";
        }

        public string CheckBrickCount()
        {
            return $"Количество кирпичей на складе: {BrickCount}";
        }
    }

    public class GlassFactory : Factory
    {
        public int GlassCount { get; set; }

        public override string Produce()
        {
            GlassCount += 500;
            return "Производство стекла";
        }

        public string CheckGlassCount()
        {
            return $"Количество стекла на складе: {GlassCount}";
        }
    }

    public class MetallurgicalFactory : Factory
    {
        public int MetalCount { get; set; }

        public override string Produce()
        {
            MetalCount += 100;
            return "Производство металла";
        }

        public string CheckMetalCount()
        {
            return $"Количество металла на складе: {MetalCount}";
        }
    }
    public class ReflectionExample
    {
        public static List<string> GetImplementingClasses(string assemblyPath, Type interfaceType)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            return assembly.GetTypes()
                .Where(type => interfaceType.IsAssignableFrom(type) && type.IsClass)
                .Select(type => type.Name)
                .ToList();
        }
    }
}
