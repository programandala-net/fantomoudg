#! /usr/bin/env gforth

\ spanish_udg.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211554

\ ==============================================================
\ Description

\ A tool to create some ZX Spectrum UDG (User Defined Graphics),
\ used for the Spanish characters, in BASIC DATA format.

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2010, 2011, 2016

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2010-05-24: First version.

\ 2011-12-24: Typo fixed: a string final quote was missing at
\ the end of the line; Gforth and bigFORTH supposed the string
\ ends at the end of line, but lina (logically) stored the rest
\ of the file as the string.
\
\ 2016-12-21: Update file header and source layout.

\ ==============================================================

decimal

: binary  ( -- ) 2 base ! ;

variable udg#  char A udg# !

: quote  ( -- ) 34 ( quote ) emit  ;

: comma  ( -- ) [char] , emit  ;

: :udg  ( a u -- )
  binary cr ." DATA " quote udg# @ emit quote  ;

: scan  ( b -- )
  comma decimal . binary  ;

: ;udg  ( a u -- )
  ."  : REM " type decimal 1 udg# +!  ;


s" inverse exclamation mark"
:udg \ ¡ = 161
  00000000 scan
  00001000 scan
  00000000 scan
  00001000 scan
  00001000 scan
  00001000 scan
  00001000 scan
  00000000 scan
;udg
s" o ordinal"
:udg \ º = 186
  00011000 scan
  00100100 scan
  00011000 scan
  00000000 scan
  00111100 scan
  00000000 scan
  00000000 scan
  00000000 scan
;udg
s" inverse question mark"
:udg \ ¿ = 191
  00000000 scan
  00010000 scan
  00000000 scan
  00010000 scan
  00100000 scan
  01000010 scan
  00111100 scan
  00000000 scan
;udg
s" A accute"
:udg \ Á = 193
  00000100 scan
  00001000 scan
  00111100 scan
  01000010 scan
  01111110 scan
  01000010 scan
  01000010 scan
  00000000 scan
;udg
s" E accute"
:udg \ É = 201
  00000100 scan
  00001000 scan
  01111110 scan
  01000000 scan
  01111100 scan
  01000000 scan
  01111110 scan
  00000000 scan
;udg
s" I accute"
:udg \ Í = 205
  00000100 scan
  00001000 scan
  00111110 scan
  00001000 scan
  00001000 scan
  00001000 scan
  00111110 scan
  00000000 scan
;udg
s" N tilde"
:udg \ Ñ = 209
  00111100 scan
  00000000 scan
  01100010 scan
  01010010 scan
  01001010 scan
  01000110 scan
  01000010 scan
  00000000 scan
;udg
s" O accute"
:udg \ Ó = 211
  00001000 scan
  00010000 scan
  00111100 scan
  01000010 scan
  01000010 scan
  01000010 scan
  00111100 scan
  00000000 scan
;udg
s" U accute"
:udg \ Ú = 218
  00000100 scan
  01001010 scan
  01000010 scan
  01000010 scan
  01000010 scan
  01000010 scan
  00111100 scan
  00000000 scan
;udg
s" U dieresis"
:udg \ Ü = 220
  01000010 scan
  00000000 scan
  01000010 scan
  01000010 scan
  01000010 scan
  01000010 scan
  00111100 scan
  00000000 scan
;udg
s" a accute"
:udg \ á = 225
  00001000 scan
  00010000 scan
  00111000 scan
  00000100 scan
  00111100 scan
  01000100 scan
  00111100 scan
  00000000 scan
;udg
s" e accute"
:udg \ é = 233
  00001000 scan
  00010000 scan
  00111000 scan
  01000100 scan
  01111000 scan
  01000000 scan
  00111100 scan
  00000000 scan
;udg
s" i accute"
:udg \ í = 237
  00001000 scan
  00010000 scan
  00000000 scan
  00110000 scan
  00010000 scan
  00010000 scan
  00111000 scan
  00000000 scan
;udg
s" n tilde"
:udg \ ñ = 241
  00000000 scan
  01111000 scan
  00000000 scan
  01111000 scan
  01000100 scan
  01000100 scan
  01000100 scan
  00000000 scan
;udg
s" o accute"
:udg \ ó = 243
  00001000 scan
  00010000 scan
  00111000 scan
  01000100 scan
  01000100 scan
  01000100 scan
  00111000 scan
  00000000 scan
;udg
s" u accute"
:udg \ ú = 250
  00001000 scan
  00010000 scan
  01000100 scan
  01000100 scan
  01000100 scan
  01000100 scan
  00111000 scan
  00000000 scan
;udg
s" u dieresis"
:udg \ ü = 252
  01000100 scan
  00000000 scan
  01000100 scan
  01000100 scan
  01000100 scan
  01000100 scan
  00111000 scan
  00000000 scan
;udg

bye
