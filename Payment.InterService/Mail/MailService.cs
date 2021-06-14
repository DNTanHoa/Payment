using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.InterService.Mail
{
    public interface IMailService
    {
        Task Send(MailServiceModel model, List<string> toMails, List<string> ccs, List<string> bccs);
    }
    public class MailService : IMailService
    {
        public Task Send(MailServiceModel model, List<string> toMails, List<string> ccs, List<string> bccs)
        {
            throw new NotImplementedException();
        }
    }
}
