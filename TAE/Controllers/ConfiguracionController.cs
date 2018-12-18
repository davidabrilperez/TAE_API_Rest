using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public class ConfiguracionController : Controller
{
    private readonly Configuracion _Configuration;
    public string cadenaConexion;
    public ConfiguracionController(IOptions<Configuracion> configuration)
    {
        _Configuration = configuration.Value;
        cadenaConexion = _Configuracion["Configuracion:BBDD"];
    }
}