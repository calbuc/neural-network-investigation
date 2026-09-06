## Neural network investigation

This project allows for the creation of neural networks of varied architectures and trains them on the MNIST dataset to test their accuracy. The implementation is done completely from scratch in C# to explore the fundamentals and algorithms that allow neural networks to function. The solution is built to answer the question of 'What effect does the architecture of a neural network have on its accuracy?'. The project was originally built as part of my A-Level Computer Science NEA.

More detail about the project, design choices and testing is available in the full writeup [Report.pdf](Report.pdf)

### Approach

Using an object oriented framework the architecture and functionality of the networks are built from first principles without use of typical machine learning libraries. This removes the abstraction that these libraries provide and allows for a ground up understanding of the fundamentals of neural networks.

In order to create a tool that is useful to answer the investigation question various features are outlined in the requirements such as:
- Creating networks
  - Customisable amount of hidden layers
  - Customisable layer sizes
  - Customisable activation function
- Loading and saving networks
  - Custom file format
- Training loop
- Testing loop
- Presenting and logging data
  - Graph to show training progress
  - Ability to view information about a current network
  - Ability to save a trained network to a file

### Reflection

The project successfully meets all of the features outlined in the requirements section of [Report.pdf](Report.pdf) but after reflection there are many improvements that would help the project to be more suitable for answering the research question.

The key area for improvement would be the usability of the project. Optimising for speed and adding more features such as a way to load multiple networks would help the project better answer the question by allowing for more comparison between networks. Having a way to create and train multiple networks automatically and then having a comparison screen would provide a more thorough answer to the question.

### How to run

- Open the Project.sln in Visual Studio or other .NET IDE
- Build the project
- Run from Program.cs
