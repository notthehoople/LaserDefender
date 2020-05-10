# LaserDefender

## Which script owns what?

### Enemy Spawner

* Order of Waves
* Spawn each wave
* Spawn each enemy in wave

### Wave Config

* Path's waypoint data
* Enemy prefab to use
* Spawn speed for wave
* Number of enemies in wave
* Movement speed of wave

### Enemy

* Enemy sprite
Enemy hit points
Shooting behaviour
Score for kill
Enemy death FXs

### Enemy Pathing

* Move the enemy along current path

## Adding Sound Effects

*     [SerializeField] AudioClip[] ballSounds;
* // Cached component references
*     AudioSource myAudioSource;
* Under start:         myAudioSource = GetComponent<AudioSource>();
*
* On collision 2d against object that needs to make the sound:
* AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
*            myAudioSource.PlayOneShot(clip);
*
* Or: AudioSource.PlayClipAtPoint(breakingSoundEffect, Camera.main.transform.position);
*      where breakingSoundEffect is the AudioClip you've added in [SerializeField]
