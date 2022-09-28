﻿using CardShop.Domain.Models;
using CardShop.Domain.Responce;
using CardShop.Domain.ViewModels.GraphicsCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Service.Interfaces
{
    public interface IGraphicsCardService
    {
        Task<IBaseResponse<IEnumerable<GraphicsCard>>> GetGraphicsCards();

        Task<IBaseResponse<GraphicsCard>> GetGraphicsCard(int id);

        Task<IBaseResponse<GraphicsCard>> GetGraphicsCardByTitle(string title);

        Task<IBaseResponse<GraphicsCardViewModel>> CreateGraphicsCard(GraphicsCardViewModel graphicsCardViewModel);

        Task<IBaseResponse<bool>> DeleteGraphicsCard(int id);

        Task<IBaseResponse<GraphicsCard>> Edit(int id, GraphicsCardViewModel graphicsCardViewModel);
    }
}
