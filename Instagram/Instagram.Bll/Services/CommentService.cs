using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using Instagram.Repoistory.Services;

namespace Instagram.Bll.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo CommentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            CommentRepo = commentRepo;
        }
        private Comment ConvertToEntity(CommentCreateDto obj)
        {
            return new Comment()
            {
                Body = obj.Body,
                PostId = obj.PostId,
                AccountId = obj.AccountId,
                ParentComentId = obj.ParentComentId,
            };
        }
        private CommentGetDto ConvertToDto(Comment obj)
        {
            return new CommentGetDto()
            {
                Body = obj.Body,
                PostId = obj.PostId,
                AccountId = obj.AccountId,
                CommentId = obj.CommentId,
                CreateTime = obj.CreateTime,
                ParentComentId = obj.ParentComentId,
                Replies = obj.Replies != null ? obj.Replies.Select(ConvertToDto).ToList()
                : new List<CommentGetDto>(),

            };
        }
        private Comment ConvertToEntity(CommentGetDto obj)
        {
            return new Comment()
            {
                Body = obj.Body,
                PostId = obj.PostId,
                AccountId = obj.AccountId,
                CommentId = obj.CommentId,
                CreateTime = obj.CreateTime,
                ParentComentId = obj.ParentComentId,
                Replies = obj.Replies != null ? obj.Replies.Select(ConvertToEntity).ToList()
                : new List<Comment>(),
            };
        }
        private CommentGetDto ConvertToDto(CommentCreateDto obj)
        {
            return new CommentGetDto()
            {
                Body = obj.Body,
                PostId = obj.PostId,
                AccountId = obj.AccountId,
                ParentComentId = obj.ParentComentId,
            };
        }
        public async Task<CommentGetDto> AddAsync(CommentCreateDto obj)
        {
            var res = await CommentRepo.AddCommmentAsync(ConvertToEntity(obj));
            
            return ConvertToDto(res);
        }

        public async Task DeleteAsync(long id)
        {
            await CommentRepo.DeleteAsync(id);
        }

        public async Task<List<CommentGetDto>> GetAllAsync()
        {
            var getAll = await CommentRepo.GetAllCommentAsync();
            return getAll.Select(c => ConvertToDto(c)).ToList();
        }

        public async Task<CommentGetDto> GetByIdAsync(long id)
        {
            var byId = await GetAllAsync();
            var res = byId.FirstOrDefault(c => c.CommentId == id);
            if (res == null)
            {
                throw new Exception($"Comment not found: {id}");
            }
            return res;
        }

        public async Task UpdateAsync(CommentGetDto obj)
        {
            await CommentRepo.UpdateAsync(ConvertToEntity(obj));
        }
    }
}
