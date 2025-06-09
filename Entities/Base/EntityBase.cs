namespace Projeto_Aplicado_II_API.Entities.Base
{
    public abstract class EntityBase
    {
        public uint Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void SetCreatedNow()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
        }

        public void SetUpdatedNow() => UpdatedAt = DateTime.Now;
    }
}
