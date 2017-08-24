using System;
using VideoMenuBLL.Services;

namespace VideoMenuBLL
{
    public class BLLFacade
    {
        public IVideoService GetVideoService()
        {
            return new VideoService();
        }
    }
}
