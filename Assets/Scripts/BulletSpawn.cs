using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public GameObject objectToSpawn;  // Prefab do projétil a ser disparado
    public Transform FirePoint;     // Local de onde os projéteis são disparados
    public int maxAmmo = 100;    // Quantidade máxima de munição
    public float reloadTime = 1f;    // Tempo total de recarga
    public float timePerBullet = 0.05f; // Tempo para recarregar uma unidade de munição

    public int currentAmmo;
    public bool reloading = false;

    void Start()
    {
        currentAmmo = maxAmmo; // Inicia com a munição máxima
    }

    void Update()
    {
        // Verifica se o jogador aperta a tecla espaço e ainda há munição disponível
        if (Input.GetKeyDown(KeyCode.Space) && currentAmmo > 0 && !reloading)
        {
            Atirar();
        }

        // Inicia o processo de recarga se a munição for zero e não estiver reloading
        if (currentAmmo <= 0 && !reloading)
        {
            StartCoroutine(Recarregar());
        }
    }

    void Atirar()
    {
        // Instancia o projétil no ponto de disparo
        // GameObject bullet = Instantiate(objectToSpawn, FirePoint.position, FirePoint.rotation);
        // bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 10, ForceMode2D.Impulse);
        particleSystem.Emit(1);

        currentAmmo--; // Reduz a munição ao disparar
    }

    IEnumerator Recarregar()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime); // Espera o tempo total de recarga

        // Recarga progressiva
        while (currentAmmo < maxAmmo)
        {
            currentAmmo++;
            yield return new WaitForSeconds(timePerBullet);
        }

        reloading = false;
    }
}
