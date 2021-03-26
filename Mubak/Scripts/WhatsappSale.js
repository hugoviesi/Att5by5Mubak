function SendMessage(description, brand, model) {
    const message = `Gostaria de comprar ${description} ${brand} ${model}`
    const url = `http://api.whatsapp.com/send?phone=5514988291862&text=${message}`

    window.open(url)
}