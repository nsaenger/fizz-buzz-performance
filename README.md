# fizz-buzz-performance

A small programm that resulted from me wanting to find out what was the best way to implement Fizz Buzz in C#. It quickly evolved into this "test-suit". There are 5 different implementations of Fizz Buzz, the performance data is the only output.

## Usage

This is a .net package so you need to have the .net-Framework in version 5 installed.

## From Release

Go to release page, download the latest version and run the programm from console. supply argument -h to know how you can modify it, default values are 1000 Fizz Buzz iterations (1, 2, Fizz, ...) and 100 Test iterations.

## From Source

You need to have the .net SDK in Version 5 installed to be able to build from source.

### With VS Code

Download repository, open it in vscode and press CTRL+F5.

### Manually
Download repository, then run
```bash
dotnet build --project src/FizzBuzz.csproj
```
in the project root to build the sources.  
Then run
```bash
dotnet run --project .\src\FizzBuzz\FizzBuzz.csproj
```
to run the program.

### Output of "-h"
```bash
Usage: fizzbuzz [options] [(unsigned int) fizzbuzz_iterations] [(unsigned int) test_iterations]
        Options:
                -h                      Displays this text
        Arguments:
                fizzbuzz_iterations     To which number fizz buzz should count (Default: 1000)
                test_iterations         How many times each function should be tested (Default: 100) 
```

### License
GNU-GPL 3