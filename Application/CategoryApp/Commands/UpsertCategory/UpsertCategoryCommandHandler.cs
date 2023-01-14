using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryApp{
    public class UpsertCategoryCommandHandler : IRequestHandler<UpsertCategoryCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertCategoryCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken)
        { 
            Category? category ;
            if(request.Id != 0)
            {
                var groupCategory = await _repo.CategoryRepo.FindByIdAsync(request.Id);
                if (groupCategory == null || groupCategory?.Data == null || groupCategory?.Error == true) 
                    return groupCategory.GetNotFoundError("Category");
                category = groupCategory?.Data;
            }else
            {
                category = new Category();
                await _repo.CategoryRepo.CreateAsync(category);
            }

            var parentId = request.ParentCategoryId;
            if(parentId > 0)
            {
                var parent = await _repo.CategoryRepo.FindByIdAsync(parentId);
                if (parent == null || parent?.Data == null || parent.Error) return parent.GetNotFoundError("ParentCategory");
            } 
            category.CategoryName = request.CategoryName;
            category.EnglishName = request.EnglishName;
            category.CategoryParentId = request.ParentCategoryId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }

    }
}
