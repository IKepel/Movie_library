using Movie_library;

var movieLibrary = new MovieLibrary();

foreach (var movie in movieLibrary)
{
    Console.WriteLine(movie);
}

Console.WriteLine($"\n{movieLibrary.GetMovie(2)}");
Console.WriteLine($"{movieLibrary[5]}");