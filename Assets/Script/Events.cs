using UnityEngine;

public static class Events
{

    #region PUBLIC_VARS
    #endregion
    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region STATIC_FUNCTIONS

    public delegate void NumnerOfWaterDrops(int i);
    public static NumnerOfWaterDrops numnerOfWaterDrops;

    public delegate void StartTheFlowOfWater();
    public static StartTheFlowOfWater startWaterFlow;

    public delegate void ToRefillWater();
    public static ToRefillWater toRefillWater;

    public delegate void ToResetTheCount();
    public static ToResetTheCount toResetTheCount;

    public delegate void ToResetTheGlassPosition();
    public static ToResetTheGlassPosition toResetTheGlassPosition;
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion



}
