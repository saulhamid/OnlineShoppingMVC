using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
   public class EmailOrderProcessor:IOrderProcessor
    {
       private EmailSettings emailsettings;
       public EmailOrderProcessor(EmailSettings email)
       {
           emailsettings = email;
       }
       public void ProcessorOrder(Cart cart, ShoppingDetails shoppingdetails)
       { 
            using(var smpt=new SmtpClient() )
            {
            smpt.EnableSsl=emailsettings.USsel;
                smpt.Host=emailsettings.ServerName;
                smpt.Port=emailsettings.Port;
                smpt.UseDefaultCredentials=false;
                
                smpt.Credentials=
                    new NetworkCredential(emailsettings.UserName,emailsettings.Password);
                StringBuilder body = new StringBuilder()
                .AppendLine("A new Order has been Submite")
                .AppendLine("...")
                .AppendLine("Items:");
                foreach(var line in cart.lines)
                {
                var subtotal= line.Product.Price*line.Quantity;
                    body.AppendFormat("{0} * {1}( Subtotal: {2:c})\n",
                        line.Quantity,
                        line.Product.ProductName,
                        subtotal);
                }
                body.AppendFormat("Total Order value :{0:c}",
                    cart.ComputeTotalValue())
                .AppendLine("...")
                .AppendLine("Ship to")
                .AppendLine(shoppingdetails.Name)
                .AppendLine(shoppingdetails.Line1)
                .AppendLine(shoppingdetails.Line2)
                .AppendLine(shoppingdetails.State)
                .AppendLine(shoppingdetails.Zip)
                .AppendLine(shoppingdetails.City)
                .AppendLine(shoppingdetails.Country)
                .AppendLine(".....")
                .AppendFormat("Gift wrap:{0}",
                shoppingdetails.GiftWrap ? "Yes":"No");
               MailMessage mailmessage=new MailMessage(
                   emailsettings.MailFromAddress,
                   emailsettings.MailToAddress,
                   "New Order Sumitted",
                   body.ToString()
                   );
               smpt.Send(mailmessage);
            }
       }
    }
}
