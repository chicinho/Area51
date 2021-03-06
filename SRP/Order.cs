﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public abstract class Order
    {
        protected readonly Cart _cart;

        protected Order(Cart cart) 
        {
            _cart = cart;
        }

        public virtual void Checkout()
        { 
            //log the order in the database
        }
    }

    public class OnlineOrder : Order
    {
        private PaymentDetails _paymentDetails;
        private readonly INotificationSerivce _notificationService;

        public OnlineOrder(Cart cart, PaymentDetails paymentDetails) : base(cart)
        {
            _paymentDetails = paymentDetails;
            _notificationService = new EmailNotificationService();
        }

        public override void Checkout()
        {
            _notificationService.Notify();
            base.Checkout();
        }
    }
}
