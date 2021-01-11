using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour {
    public static NpcSpawner instance;
    public float reqDistance;
    public Spawn[] spawns;
    public GameObject NpcPrefab;
    public GameObject NpcHolder;

    public List<Color> colorsToSpawn;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        colorsToSpawn = new List<Color>();
    }

    private void Update() {
        if(colorsToSpawn.Count>0) {
            for(int x = 0;x<colorsToSpawn.Count;x++) {
                Color c = colorsToSpawn[x];
                if(SpawnNPC(c)) {
                    colorsToSpawn.Remove(c);
                    x--;
                }
            }
        }
    }

    public void RequestSpawnNPC(Color color) {
        colorsToSpawn.Add(color);
    }

    bool SpawnNPC(Color color) {
        List<Spawn> viableSpawns = new List<Spawn>();
        foreach(Spawn s in spawns) {
            if(s.IsValid(reqDistance))
                viableSpawns.Add(s);
        }
        if(viableSpawns.Count == 0)
            return false;
        Spawn choice = viableSpawns[Random.Range(0, viableSpawns.Count)];
        choice.Use();
        NpcController newNPC = Instantiate(NpcPrefab, choice.transform.position, Quaternion.identity, NpcHolder.transform).GetComponent<NpcController>();
        newNPC.color = color;
        newNPC.direction = choice.validDirections[Random.Range(0, choice.validDirections.Length)];
        newNPC.UpdateAnim();
        return true;
    }
}
