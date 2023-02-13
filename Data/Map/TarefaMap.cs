using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data.Map
{
    
        public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
        {
            public void Configure(EntityTypeBuilder<TarefaModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
                builder.Property(x => x.Description).HasMaxLength(1000);
            }
     
        }
}
