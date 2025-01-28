console.log('Hello, Node.js!');


// Import Express using ES module syntax
import express from 'express';
import cors from 'cors';
//import sql from 'mssql/msnodesqlv8.js';
import sql from 'mssql';
import https from 'https';
import fs from 'fs';
import {format} from 'date-fns'


class WeatherForecast {
  constructor(date, temperatureC, summary) {
    this.date = format(date, 'yyyy-MM-dd');

    this.temperatureC = temperatureC;
    this.summary = summary;
    this.temperatureF = Math.round(this.temperatureC / 0.5556);
  }
}


// Define your database connection configuration
const config = {
  user: 'test',
  password: 'test',
  server: '127.0.0.1',          // Replace with your database server address (e.g., localhost)
  //server: '(localdb)\\local)',          // Replace with your database server address (e.g., localhost)
  //server: '\\\\.\\pipe\\LOCALDB#FA144DC9\\tsql\\query',
  //server: '(localdb)\\MSSQLLocalDB',
  //database: 'Emne4Database', // Replace with your database name
  database: 'Emne4Database', // Replace with your database name
  //driver: 'ODBC Driver 17 for SQL Server',
  //driver: 'odbc',
  dialect: "mssql",
  //connectionstring: 'DSN=test',
  options: {
    encrypt: false, // Enable encryption (useful for Azure SQL)
    trustServerCertificate: true, // Use this if connecting to a local SQL Server or a server without a valid SSL certificate
    trustedConnection: true,  // Use Windows Authentication
  },
  //  authentication: {
  //    type: 'ntlm',  // Windows authentication
  //    options: {
  //      domain: '',  // Optional, leave empty if not using a domain
  //    }
  //  }
};

// Read SSL certificate and key for HTTPS
const options = {
  key: fs.readFileSync('server.key'), // Path to your private key file
  cert: fs.readFileSync('server.crt'), // Path to your certificate file
  passphrase: 'test',
};

async function queryDatabase() {
  try {
    // Connect to the database
    await sql.connect(config);
    console.log('Connected to LocalDB Database!');

    // Example query: Select all rows from a table
    const result = await sql.query`SELECT * FROM forecast`; // Replace 'your_table_name' with the actual table name
    console.log(result.recordset); // Output the result of the query
  } catch (err) {
    console.error('Error connecting to LocalDB database:', err);
  } finally {
    // Close the database connection
    await sql.close();
  }
}


// Create an Express application
const app = express();
app.use(cors());
// Define a route
app.get('/WeatherForecast', async (req, res) => {
  // res.send('Hello, World!');
  try{
    await sql.connect(config)
    const result = await sql.query('SELECT * FROM forecast');
    const forecasts = result.recordset.map(f => new WeatherForecast(f.date, f.temperatureC, f.summary));
    res.json(forecasts);
  }
  catch(err){
    console.error('Error connecting to the database:', err);
    res.status(500).send('Error fetching data');
  }
  finally{
    await sql.close();
  }
});



// Start the server
const PORT = 7175;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});

// Start the server on port 7175 with HTTPS
// https.createServer(options, app).listen(7175, () => {
//   console.log('Server is running on https://localhost:7175');
// });

queryDatabase();