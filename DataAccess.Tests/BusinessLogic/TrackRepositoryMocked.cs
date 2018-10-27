using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using DataAccess;
using DataAccess.Repositories;
using Models;
using Moq;

namespace ClassLibrary1
{
    public class TrackRepositoryMocked
    {
        private readonly List<Track> _tracks;

        public TrackRepositoryMocked() {
            _tracks = GetTracks();
        }

        public IUnitOfWork GetInstance() {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(c => c.Tracks).Returns(GetTrackRepositoryMocked);
            return mocked.Object;
        }

        private ITrackRepository GetTrackRepositoryMocked() {
            var trackMocked = new Mock<ITrackRepository>();
            trackMocked.Setup(c => c.GetAll()).Returns(_tracks);
            return trackMocked.Object;
            //con esto decimos que setiemos la funcion GEtAll
            //por la data falseada que hemos generado
        }

        private List<Track> GetTracks() {
            //var fixture = new Fixture(); //instancio el metodo fixture para generar data
            //var tracks = fixture.CreateMany<Track>(10).ToList();
            //for (int i = 0; i < 10; i++) {
            //    tracks[i].TrackId = i + 1;
            //}
            //return tracks;

            return new List<Track> {
                new Track{ TrackId = 1, Composer = "Cibertec"},
                new Track{ TrackId = 2, Composer = "Cibertec2"}
            };
        }
    }
}
