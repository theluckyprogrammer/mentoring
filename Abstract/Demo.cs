using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abstract
{
    /// <summary>
    /// Abstract base class for demonstrations.
    /// </summary>
    public abstract class Demo
    {
        /// <summary>
        /// Name of the demonstration. Internally accessible within the assembly.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Constructor to initialize the demonstration name.
        /// </summary>
        /// <param name="name">Name of the demonstration.</param>
        public Demo(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Default parameterless constructor.
        /// Derived classes should have a public parameterless constructor
        /// to be dynamically created by the static Run(Type) method.
        /// </summary>
        public Demo()
        {
            // This constructor is important for Activator.CreateInstance(type),
            // if derived classes do not explicitly define a parameterless constructor
            // and have other constructors.
        }

        /// <summary>
        /// Abstract method to run the demonstration logic.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Dynamically creates an instance of the specified demonstration type (derived from Demo)
        /// and executes its Run() method.
        /// </summary>
        /// <param name="demoType">The type of demonstration to create and run. Must inherit from Demo and have a public parameterless constructor.</param>
        /// <exception cref="ArgumentNullException">Thrown if demoType is null.</exception>
        /// <exception cref="ArgumentException">Thrown if demoType does not inherit from Demo, is an abstract type, or an instance cannot be created.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an instance of the type cannot be created (e.g., missing parameterless constructor or constructor threw an exception).</exception>
        public static void Run(Type demoType)
        {
            if (demoType == null)
            {
                throw new ArgumentNullException(nameof(demoType), "Demonstration type cannot be null.");
            }

            // Check if the type inherits from Demo
            if (!typeof(Demo).IsAssignableFrom(demoType))
            {
                throw new ArgumentException($"Type '{demoType.FullName}' does not inherit from the Demo class.", nameof(demoType));
            }

            // Check if the type is not abstract
            if (demoType.IsAbstract)
            {
                throw new ArgumentException($"Cannot create an instance of the abstract type '{demoType.FullName}'.", nameof(demoType));
            }

            Demo instance;
            try
            {
                // Create an instance of the type. Requires a public parameterless constructor.
                // If a derived class does not have an explicit parameterless constructor
                // but has other constructors, this will throw an exception.
                // If a derived class has no explicit constructors, the compiler
                // will generate a default public parameterless constructor that calls base().
                instance = (Demo)Activator.CreateInstance(demoType);
            }
            catch (MissingMethodException ex) // Specific exception for missing constructor
            {
                throw new InvalidOperationException($"Failed to create an instance of type '{demoType.FullName}'. The type must have a public parameterless constructor.", ex);
            }
            catch (Exception ex) // General exception if the constructor throws an error or other issues with Activator.CreateInstance
            {
                throw new InvalidOperationException($"An error occurred while creating an instance of type '{demoType.FullName}'. Details: {ex.Message}", ex);
            }

            // Theoretically, Activator.CreateInstance should throw an exception instead of returning null,
            // but an additional check doesn't hurt.
            if (instance == null)
            {
                throw new InvalidOperationException($"Activator.CreateInstance returned null for type '{demoType.FullName}', which should not happen if no exception was thrown.");
            }

            // Call the Run() method on the created instance
            instance.Run();
        }
    }
}
