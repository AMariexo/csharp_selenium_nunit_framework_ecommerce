//get packages
const express = require('express');
const fs = require('fs');
const app = express();

app.get("/login", (req, res) => {
    const data = fs.readFileSync('./TestData/loginData.json');
    res.setHeader('Content-Type', 'application/json');
    res.json(JSON.parse(data));
});

app.listen(3000, () => {
    console.log("API is running");
        
})