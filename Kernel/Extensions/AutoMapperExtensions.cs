﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace Kernel.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination>
       IgnoreAllVirtual<TSource, TDestination>(
           this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                                     p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
}
