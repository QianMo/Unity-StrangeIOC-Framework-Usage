using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.pool.api;

public class Signals {};


// First signal !!
public class GameUpAndReadySignal : Signal{};


public class ReturnInstanceSignal : Signal<PoolableView>{};


public class ShowLevelPanelSignal : Signal{};
public class HideLevelPanelSignal : Signal {};
public class StartLevelSignal : Signal<int>{};
public class SpawnPlayerShipSignal : Signal{};
public class HitByLaserSignal : Signal<PoolableView, PlayerShipLaserView, int>{};
public class ScoreGainedSignal : Signal<int, Vector3>{};
public class ScoreUpdatedSignal : Signal<int>{};