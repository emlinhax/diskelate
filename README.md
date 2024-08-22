# diskelate

The Task "SilentCleanup" is ran as Administrator by default. \
It creates a temporary folder in temp and places a few dlls there that it later loads. \
We just wait for that to happen and then replace one of the DLLs with our own.

It really is that simple.

Notes:
- This is a Race Condition so it is not guaranteed to work 100% of the time.
- This is NOT A LOCAL PRIVILEGE ESCALATION. This is only a UAC bypass.
<br>

# Tested on:
- Windows 10 Build 20348
