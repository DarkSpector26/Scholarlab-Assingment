using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalData", menuName = "Animal Data", order = 51)]
public class AnimalData : ScriptableObject
{
    public string animalName;
    public string AnimalDescription;
    public FlyingCategory flyingCategory;
    public InsectCategory insectCategory;
    public DietCategory dietCategory;
    public SocialCategory socialCategory;
    public ReproductionCategory reproductionCategory;
}


public enum FlyingCategory { Flying, NonFlying }

public enum InsectCategory { Insect, NonInsect }


public enum DietCategory { Omnivorous, Herbivorous }
public enum SocialCategory { Group, Solo }


public enum ReproductionCategory { LaysEggs, GivesBirth }
