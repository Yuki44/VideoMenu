using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL;
using VideoMenuEntity;
using static System.Console;

namespace VideoMenuBLL.Services
{
    class VideoService : IVideoService
    {
        public Video Create(Video vid)
        {
            #region Add Videos

            Video newVid;

            FakeDB.videos.Add(newVid = new Video()
            {
                Title = vid.Title,
                Id = FakeDB.Id++
            });

            return newVid;

            #endregion //Add Videos
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            FakeDB.videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return FakeDB.videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.videos);
        }

        public Video Update(Video vid)
        {
            var videoFromDB = Get(vid.Id);
            if (videoFromDB == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDB.Title = vid.Title;
            videoFromDB.Id = vid.Id;
            return videoFromDB;
        }
    }
}
