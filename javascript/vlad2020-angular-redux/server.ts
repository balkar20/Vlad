// //Author Vlad Balkarov//vlad//

// These are important and needed before anything else
import 'zone.js/dist/zone-node';
import 'reflect-metadata';

import { enableProdMode } from '@angular/core';

import * as express from 'express';
import { join } from 'path';

// Faster server renders w/ Prod mode (dev mode never needed)
enableProdMode();

// Express server
const app = express();

// //vlad// const PORT = process.env.PORT;
const DIST_FOLDER = join(process.cwd(), 'dist');

// * NOTE :: leave this as require() since this file is built Dynamically from webpack
const { AppServerModuleNgFactory, LAZY_MODULE_MAP } = require('./dist/server/main');

// Express Engine
import { ngExpressEngine } from '@nguniversal/express-engine';
// Import module map for lazy loading
import { provideModuleMap } from '@nguniversal/module-map-ngfactory-loader';

// //vlad//>//
import {appBaseDiTokenLocalStorage, appBaseDiTokenSessionStorage, appBaseDiTokenWindow} from './src/app/base/base-di';
import {appCoreSettings} from './src/app/core/core-settings';
const PORT = appCoreSettings.hostPort; // //vlad// process.env.PORT;
const domino = require('domino');
const sessionStorage = require('sessionstorage');
const LocalStorage = require('node-localstorage').LocalStorage;
const localStorage = new LocalStorage('./scratch');
const fs = require('fs');
const path = require('path');
const template = fs.readFileSync(path.join('.', __dirname, 'dist', 'browser', 'index.html')).toString();
const win = domino.createWindow(template);
// //vlad//<//

app.engine('html', ngExpressEngine({
  bootstrap: AppServerModuleNgFactory,
  providers: [
    // //vlad//>//
    {provide: appBaseDiTokenLocalStorage, useValue: localStorage},
    {provide: appBaseDiTokenSessionStorage, useValue: sessionStorage},
    {provide: appBaseDiTokenWindow, useValue: win},
    // //vlad//<//
    provideModuleMap(LAZY_MODULE_MAP)
  ]
}));

app.set('view engine', 'html');
app.set('views', join(DIST_FOLDER, 'browser'));

// TODO: implement data requests securely
app.get('/api/*', (req, res) => {
  res.status(404).send('data requests are not supported');
});

// Server static files from /browser
app.get('*.*', express.static(join(DIST_FOLDER, 'browser')));

// All regular routes use the Universal engine
app.get('*', (req, res) => {
  res.render('index', { req });
});

// Start up the Node server
app.listen(PORT, () => {
  console.log(`Node server listening on http://localhost:${PORT}`);
});
