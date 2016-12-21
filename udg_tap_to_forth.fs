#! /usr/bin/env gforth

\ udg_tap_to_forth.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612212324

\ ==============================================================
\ Description

\ This program converts a ZX Spectrum TAP file, containing User
\ Defined Graphics, to hex data ready to be used in a Forth
\ program.

\ ==============================================================
\ Usage

\ ./udg_tap_to_forth.fs input_file.tap > output_file.fs

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2015, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2015-03-23: Start.
\
\ 2016-03-01: Fix, improve.
\
\ 2016-12-21: Update file header and source layout. Fix `hex8.`,
\ `next-udg`, `behead`. Factor.

\ ==============================================================
\ Main

variable scans  \ counter
variable udg    \ counter

144 constant first-udg
8 constant scans/udg

: .scan  ( n -- )
  base @ >r s>d hex <# # # '$' hold #> type space r> base !  ;

: last-scan?  ( -- f )  scans @ scans/udg =  ;

: next-scan  ( -- )  1 scans +!  ;

: next-udg  ( -- )  1 udg +!  scans off  ;

: .udg  ( n -- )  s>d space <# # # # '#' hold #> type space  ;

: .store-udg  ( -- )  udg @ .udg ." udg!" cr  ;

: finish-udg  ( -- )  .store-udg next-udg  ;

: init  ( -- )  scans off  first-udg udg !  ;

: udgs>forth  ( ca len -- )
  init  bounds ?do
    i c@ .scan next-scan last-scan? if  finish-udg  then
  loop  ;
  \ Convert the UDG definitions contained in the memory zone
  \ _ca len_ (8 bytes per UDG) to Forth source printed to
  \ standard output.

: behead  ( ca1 len1 -- ca2 len2 )  24 /string 1-  ;
  \ Remove the TAP file header from the TAP file contents _ca1
  \ len1_, and the checksum byte of the data block, resulting a string
  \ _ca2 len2_ that contains only the actual data of the file.

: udgtap>forth ( ca len -- )  slurp-file behead udgs>forth  ;
  \ Convert the UDGs contained in TAP file _ca len_ to Forth
  \ source printed to standard output.

1 arg udgtap>forth bye
