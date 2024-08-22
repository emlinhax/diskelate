# diskelate

The Task "SilentCleanup" is ran as Administrator by default. \
I know this has been abused before. This is just another way of doing it.

# Explanation:
The Task creates a temporary folder in temp and places a few dlls there that it later loads. \
We just wait for that to happen and then replace one of the DLLs with our own. \
This works because Windows (or cleanmgr) does not validate the modules it loads.

It really is that simple.

Notes:
- This is a Race Condition so it is not guaranteed to work 100% of the time.
- This is NOT A LOCAL PRIVILEGE ESCALATION. This is only a UAC bypass.


# Usage:
You should be able to tell by reading the code but just in case:
1. Place your DLL in the same folder as diskelate.exe and name it "payload.dll"
2. Run the program

# Tested on:
- Windows 10 Build 20348
