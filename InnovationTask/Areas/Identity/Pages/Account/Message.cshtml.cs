using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovationTask.Data;
using InnovationTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InnovationTask.Areas.Identity.Pages.Message
{
        public class MessageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public PhoneMessage PhoneMessage { get; set; }

        public MessageModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost([Bind("ID,message,phoneNumber")] PhoneMessage phoneMessage)
        {

            try
            {
                var phoneNumbers = from row in _context.phoneNumbers
                                   select row;

                var phonemessage = from row in _context.phoneMessages
                                   select row;
                int count = phonemessage.Count();
                int countt = phoneNumbers.Count(); // 1st round-trip
            int dif = countt - count;
            int Index;
            if (dif>=10)
            {
                Index = 10;
            }
            else
            {
                Index = dif;
            }
                if (count != countt)
                {


                for (int i = 0; i < Index; i++)
                {
                    int index = new Random().Next(countt);
                    



                        PhoneNumbers msgg = phoneNumbers.Skip(index).FirstOrDefault(); // 2nd round-trip
                        string phone = msgg.PhoneNumber;
                        string msg = phoneMessage.message;
                        var exist = _context.phoneMessages.Where(x => x.phoneNumber.Contains(phone)).FirstOrDefault();
                        if (exist != null)
                        {
                            --i;
                        }
                        else
                        {
                            PhoneMessage phmsg = new PhoneMessage()
                            {
                                phoneNumber = phone,
                                message = msg
                            };
                            

                            _context.Add(phmsg);
                            await _context.SaveChangesAsync();
                        }
                    
                   

                    ViewData["UserMessage"] = "Messages Had been sent";
                }
                }
                else
                {
                    if (count==0)
                    {
                        ViewData["UserMessage"] = "There is no phone numbers ";

                    }
                    else
                    { 
                    ViewData["UserMessage"] = "All Phone Numbers Had Already Recived Messages ";
                    }
                    return Page();
                }
            }
            catch (Exception)
            {
                return Page();
            }

            return Page();
        }
    }
}
