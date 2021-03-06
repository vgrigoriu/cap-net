﻿using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class AreaValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public AreaValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from area in Entity.Areas
                       from error in GetErrors(area)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(Area area)
        {
            var areaValidators = from type in Assembly.GetExecutingAssembly().GetTypes()
                                 where typeof(IValidator<Area>).IsAssignableFrom(type)
                                 select (IValidator<Area>)Activator.CreateInstance(type, area);

            return from validator in areaValidators
                   from error in validator.Errors
                   select error;
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }
    }
}
