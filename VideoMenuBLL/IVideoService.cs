using System;
using System.Collections.Generic;
using VideoMenuEntity;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        Video Update(Video vid);
        //D
        bool Delete(int Id);
    }
}
