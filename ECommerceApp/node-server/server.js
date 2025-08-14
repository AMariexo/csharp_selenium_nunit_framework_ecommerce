//get packages
const express = require('express');
const fs = require('fs');
const app = express();
const path = require('path');
const PORT = 3000;


app.get("/login", (req, res) => {
    const filePath = path.join(__dirname, '..', 'TestData', 'loginData.json');
    const data = fs.readFileSync(filePath);
    res.setHeader('Content-Type', 'application/json');
    res.json(JSON.parse(data));
});

app.listen(PORT, () => {
    console.log(`Test data server running at http://localhost:${PORT}`);
});