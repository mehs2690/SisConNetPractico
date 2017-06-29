function StringBuilder(value) {
    /// <summary>
    /// Función que realiza un constructor
    /// de cadena de caracteres
    /// </summary>
    /// <param name="value">string que se concatenará </param>
    this.strings = new Array("");
    this.append(value);
}

StringBuilder.prototype.append = function (value) {
    /// <summary>
    /// Método función que realiza la concatenación
    /// de los caracteres para la cadena final
    /// </summary>
    /// <param name="value">valor que se concatenará</param>
    if (value)
        this.strings.push(value);
};

StringBuilder.prototype.clear = function () {
    /// <summary>
    /// función método que limpia el constructor
    /// de cadenas.
    /// </summary>
    this.strings.length = 1;
};

StringBuilder.prototype.toString = function () {
    /// <summary>
    /// función método que realiza 
    /// la construcción de la cadena.
    /// </summary>
    /// <returns type="string">cadena de caracteres</returns>
    return this.strings.join("");
};