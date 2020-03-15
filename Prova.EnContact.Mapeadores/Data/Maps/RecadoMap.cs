using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Mapeadores.Data.Maps
{
    public class RecadoMap : IEntityTypeConfiguration<Recado>
    {
        public void Configure(EntityTypeBuilder<Recado> builder)
        {
        }
    }
}
