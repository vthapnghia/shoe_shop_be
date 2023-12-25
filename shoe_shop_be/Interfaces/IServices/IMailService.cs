using shoe_shop_be.Helpers;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}
