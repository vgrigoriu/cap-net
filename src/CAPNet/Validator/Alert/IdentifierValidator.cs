﻿using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentifierValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public IdentifierValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new IdentifierError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Identifier.DoesNotContainsRestrictedChars();
            }
        }
    }
}
