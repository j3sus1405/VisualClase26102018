using AutoFixture;
using DataAccess;
using DataAccess.Repositories;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Test
{
    public class TrackRepositoryMocked
    {
        private readonly List<Track> _tracks;

        public TrackRepositoryMocked()
        {
            _tracks = GetTracks();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(c => c.Tracks).Returns(GetTrackRepositoryMocked);
            return mocked.Object;
        }

        private ITrackRepository GetTrackRepositoryMocked()
        {
            var trackMocked = new Mock<ITrackRepository>();
            trackMocked.Setup(c => c.GetAll()).Returns(_tracks);
            trackMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id)=>_tracks.FirstOrDefault(x=>x.TrackId==id)); 
            //setee cualquier parametro de este tipo para no mandarle uno en especifico
            return trackMocked.Object;
            //con esto decimos que setiemos la funcion GEtAll
            //por la data falseada que hemos generado
        }

        private List<Track> GetTracks()
        {
            var fixture = new Fixture(); //instancio el metodo fixture para generar data
            var tracks = fixture.CreateMany<Track>(10).ToList();
            for (int i = 0; i < 10; i++)
            {
                tracks[i].TrackId = i + 1;
            }
            return tracks;
        }
    }
}
