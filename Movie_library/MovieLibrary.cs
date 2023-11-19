using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_library
{
    public class MovieLibrary : IEnumerable
    {
        private Dictionary<int, string> _ordinaryMovies = new Dictionary<int, string>
        {
            { 1, "Harry Potter" },
            { 2, "The Lord of the Rings" },
            { 3, "Transformers" }
        };

        private Dictionary<int, string> _onlyAdultMovies = new Dictionary<int, string>
        {
            { 101, "Gladiator" },
            { 102, "Piranha 3D" },
            { 103, "Room in Rome" }
        };

        public string this[int movieNum]
        {
            get
            {
                if (IsNightTime())
                {
                    if (_onlyAdultMovies.ContainsKey(movieNum))
                        return _onlyAdultMovies[movieNum];
                    if (_ordinaryMovies.ContainsKey(movieNum))
                        return _ordinaryMovies[movieNum];
                }
                else
                {
                    if (_ordinaryMovies.ContainsKey(movieNum))
                        return _ordinaryMovies[movieNum];
                }

                throw new KeyNotFoundException("Movie not found");
            }
        }

        public string GetMovie(int movieNum)
        {
            try
            {
                return this[movieNum];
            }
            catch (KeyNotFoundException)
            {
                return "Movie not found";
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (IsNightTime())
            {
                foreach (var movie in _ordinaryMovies.Values)
                {
                    yield return movie;
                }
                foreach (var movie in _onlyAdultMovies.Values)
                {
                    yield return movie;
                }
            }
            else
            {
                foreach (var movie in _ordinaryMovies.Values)
                {
                    yield return movie;
                }
            }
        }

        private bool IsNightTime()
        {
            var now = DateTime.Now;
            return now.Hour >= 23 || now.Hour < 7;
        }
    }
}