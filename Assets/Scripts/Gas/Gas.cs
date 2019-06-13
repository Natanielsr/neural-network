using System;
public class Gas
{
    public Guid id;
    DateTime creationDate;

    public DateTime finishDate { get; set; }
    public float GasUnit { get; set; }

    public float Diference = 5f;

    public Gas(Guid id, float GasUnit){
        this.id = id;
        this.GasUnit= GasUnit;

        creationDate = DateTime.Now;
        finishDate = creationDate.AddSeconds(GasUnit+Diference);
    } 
}
