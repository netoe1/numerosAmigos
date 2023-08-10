using UnityEngine;

public class ReprodutorSom
{
    public string PATHPASTA_AUDIOS { get; set; }

    private GameObject gameObject_atrelado;
    private AudioSource audioSource;

    private const float STD_VOLUME = 1.0f;
    public ReprodutorSom(string __path_audios, GameObject __gameObject)
    {
        this.PATHPASTA_AUDIOS = __path_audios;
        this.gameObject_atrelado = __gameObject;
    }

    public void reproduzirArquivo(string filename)
    {
        audioSource = gameObject_atrelado.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            //this.reprodutorAudioLog("O gameobject atrelado possui audiosource");
            audioSource.clip = Resources.Load<AudioClip>(this.PATHPASTA_AUDIOS + '/' + filename);
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                this.reprodutorAudioError("O arquivo de áudio não foi encontrado");
            }

        }
        else
        {
            //this.reprodutorAudioWarning("O gameobject atrelado não possui audio source");
            //this.reprodutorAudioWarning("A API irá adicionar um audio source automaticamente.");
            addAudioSource();
            reproduzirArquivo(filename);
        }
    }

    private void reprodutorAudioError(string desc)
    {
        Debug.LogError("ReproduzirAudio ERRO:" + desc);
    }
    private void reprodutorAudioLog(string desc)
    {
        Debug.Log("ReproduzirAudio:" + desc);
    }
    private void reprodutorAudioWarning(string desc)
    {
        Debug.LogWarning("ReproduzirAudioWarning:" + desc);
    }

    private void addAudioSource()
    {
        audioSource = gameObject_atrelado.AddComponent<AudioSource>();
    }

    private void set_stdConfigAudioSource()
    {
        audioSource.volume = STD_VOLUME;
        audioSource.playOnAwake = false;
    }

};