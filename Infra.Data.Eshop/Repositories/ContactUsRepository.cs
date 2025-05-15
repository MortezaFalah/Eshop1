using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.ContactUs;
using Domain.Eshop.ViewModels.Common;
using Domain.Eshop.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Eshop.Extensions;


namespace Infra.Data.Eshop.Repositories
{
    public class ContactUsRepository(Context.EshopContext _context) : IContactUsRepository
    {
        public async Task<bool> AddAsync(CreateContactUsViewModel model)
        {
            ContactUs contactUs = new ContactUs()
            {
                Fullname = model.FullName,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Email = model.Email,
                Mobile = model.Mobile,
                Title = model.Title,
                Ip = model.Ip ?? string.Empty,

            };

            await _context.AddAsync(contactUs);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FilterContactUsAdminViewModel> FilterAsync(FilterContactUsAdminViewModel model)
        {
            var Query = _context.ContactUs.AsQueryable();

            if (model.Answerstatus != null)
            {
                switch (model.Answerstatus)
                {
                    case StatusOfAnswer.Answered:
                        Query = Query.Where(r => r.AnswerUserId != null);
                        break;

                    case StatusOfAnswer.Pending:
                        Query = Query.Where(r => r.AnswerUserId == null);
                        break;
                }
            }

            //if(model.FilterAllString != null)
            //{
            //    Query = Query.Where(r=>r.Mobile ==  model.FilterAllString 
            //    || r.Fullname == model.FilterAllString || r.Title ==model.FilterAllString 
            //    || r.Description == model.FilterAllString || r.Email == model.FilterAllString);
            //}
            if (!string.IsNullOrWhiteSpace(model.FilterAllString))
            {
                Query = Query.Where(T =>
                T.Email.Contains(model.FilterAllString) ||
                T.Mobile.Contains(model.FilterAllString) ||
                T.Title.Contains(model.FilterAllString) ||
                T.Description.Contains(model.FilterAllString) ||
                T.Fullname.Contains(model.FilterAllString));
            }
            if (!string.IsNullOrEmpty(model.StartDate))
            {
                string? NewDate = Convert.ToDateTime(model.StartDate).ToMiladi();
                Query = Query.Where(r => r.CreateDate >= Convert.ToDateTime(NewDate));
            }
            if (!string.IsNullOrEmpty(model.EndDate))
            {
                string? NewDate = Convert.ToDateTime(model.EndDate).ToMiladi();
                Query = Query.Where(r => r.CreateDate <= Convert.ToDateTime(NewDate));
            }
            Query.OrderByDescending(f => f.CreateDate);

            await model.Paging(Query.Select(g=> new AdminContactUsViewModel
            {
                FullName =  g.Fullname,
                AnswerUserid = g.AnswerUserId,
                CreateDate = g.CreateDate,
                Email = g.Email,    
                Mobile = g.Mobile,  
                Title = g.Title,

            }));
            return model;
        }
    }
}
