/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.razor",
        "./Pages/**/*.razor",
        "./Components/**/*.razor",
        "./Shared/**/*.razor",
        "./wwwroot/**/*.html",
        "./wwwroot/**/*.css"
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}