using galdino.funcional.domain.core.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace galdino.funcional.domain.core.Entity.Base
{
	public class BaseEntity : IEntity
	{
        [Column("dh_DateInclusionRegistration")]
        public DateTime DateInclusionRegistration { get; set; }

        [Column("dh_DateChangeRegistration")]
        public DateTime DateChangeRegistration { get; set; }

        [Column("Active")]
        public string Active { get; set; }
    }
}
