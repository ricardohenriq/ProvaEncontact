using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Mapeadores.Data.Maps
{
    public class AgrupamentoMap : IEntityTypeConfiguration<Agrupamento>
    {
        public void Configure(EntityTypeBuilder<Agrupamento> builder)
        {
            builder
                .HasMany(x => x.RecadosResposta)
                .WithOne(x => x.Agrupamento)
                .HasForeignKey(x => x.IdPai)
                .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasOne(x => x.RecadoInicial)
            //    .WithOne(s => s.Agrupamento)
            //    .HasForeignKey<Recado>(x => x.IdPai)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
