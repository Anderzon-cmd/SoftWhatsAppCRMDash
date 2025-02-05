/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml",
    ],
    darkMode: 'class',
    theme: {

        extend: {},

    },
    safelist: [
        'bg-red-500',
        'bg-green-500',
        'bg-orange-500',
        'bg-yellow-500',
        // Agrega aquí todas las clases dinámicas posibles
    ],
    plugins: []
}

