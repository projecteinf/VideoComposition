using System;
using model.entitats;

Console.WriteLine("Hello, World!");
model.entitats.File file = new model.entitats.File();
file.Name = "File1";
file.Path = "/home/user";
file.Size = 1024;
file.Duration = 3.5f;
Console.WriteLine(file);