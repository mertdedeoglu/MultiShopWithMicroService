﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddresssCommand
    {
        public int Id { get; set; }

        public RemoveAddresssCommand(int id)
        {
            Id = id;
        }
    }
}
