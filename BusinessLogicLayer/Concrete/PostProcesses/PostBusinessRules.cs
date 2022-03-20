using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.PostProcesses
{
    public partial class PostManager
    {
        private IResult CheckIsPostChanged(Post post)
        {
            var oldPost = _postDal.GetOne(p => p.PostId == post.PostId);
            if (oldPost.Title != post.Title || oldPost.PostContent != post.PostContent)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Butonu inaktif yap...");
        }

        private IResult CheckIsPostDeleted(Post post)
        {
            if (!post.Status)
            {
                return new ErrorResult("Böyle bir post bulunamadı");
            }
            return new SuccessResult();
        }
    }
}
