using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StraightMotions : MonoBehaviour
{
    public float kecepatanDefault = 5f;
    public float jarakDefault = 10f;

    public Slider kecepatanSlider;
    public Slider jarakSlider;
    public TMP_Text stopwatchText;

    private float kecepatan;
    private float jarak;
    private float waktuTempuh;
    private bool sedangBergerak;

    private bool selesaiBergerak = false;

    private void Start()
    {
        ResetSimulasi();
    }

    private void Update()
    {
        if (sedangBergerak)
        {
            WaktuBerjalan();
            MobilBergerak();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MulaiSimulasi();
        }
        if (Input.GetKeyDown(KeyCode.Space) && selesaiBergerak == true)
        {
            selesaiBergerak = false;
            ResetSimulasi();
            MulaiSimulasi();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void MulaiSimulasi()
    {
        kecepatan = kecepatanSlider.value;
        jarak = jarakSlider.value;
        sedangBergerak = true;
    }

    private void WaktuBerjalan()
    {
        waktuTempuh += Time.deltaTime;
        stopwatchText.text = "Waktu Tempuh: " + waktuTempuh.ToString("F2") + "s";
    }

    private void MobilBergerak()
    {
        float jarakDitempuh = kecepatan * waktuTempuh;
        float persentaseJarakDitempuh = jarakDitempuh / jarak;

        if (persentaseJarakDitempuh >= 1f)
        {
            HentikanSimulasi();
        }
        else
        {
            transform.Translate(Vector3.forward * kecepatan * Time.deltaTime);
        }
    }

    private void HentikanSimulasi()
    {
        sedangBergerak = false;
        selesaiBergerak = true;
        Debug.Log("Simulasi selesai. Waktu tempuh: " + waktuTempuh.ToString("F2") + "s");
    }

    private void ResetSimulasi()
    {
        sedangBergerak = false;
        waktuTempuh = 0f;
        stopwatchText.text = "Waktu Tempuh: 0s";
        transform.position = new Vector3(0f, 0f, 0f);
    }
}
